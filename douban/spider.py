#-*- codeing = utf-8 -*-
#@Time :2020/5/17 15:40
#@Author : 李康迪
#@File : spider.py
#@Software： PyCharm
from bs4 import BeautifulSoup
import re
import urllib.request
import urllib.error
import xlwt
import sqlite3
findLink=re.compile(r'<a href="(.*?)">')
#获取图片
findImgSrc=re.compile(r'<img.*src="(.*?)"',re.S)#包括换行
#获取片名
findTitle=re.compile(r'<span class="title">(.*)</span>')
findRating=re.compile(r'<span class="rating_num" property="v:average">(.*)</span>')
findJudge=re.compile(r'<span>(\d*)人评价</span>')
findInq=re.compile(r'<span class="inq">(.*)</span>')
findBd=re.compile(r'<p class="">(.*?)</p>',re.S)
def main():
    baseurl="https://movie.douban.com/top250?start="
    #1爬取网页
    datalist=getData(baseurl)
    dbpath="movie.db"
    # 3保存数据
    savepath=".\\豆瓣电影top250.xls"
    saveData(datalist,savepath)
    saveData2DB(datalist,dbpath)
    #askURL("https://movie.douban.com/top250?start=0")
def getData(baseurl):
    datalist=[]
    for i in range(0,10): #调用10次
        url=baseurl+str(i*25)
        html=askURL(url)
    # 2解析数据
        soup=BeautifulSoup(html,"html.parser")
        for item in soup.find_all('div',class_="item"): #查找
            data=[] #保存一部电影的信息
            item=str(item)
            link=re.findall(findLink,item)[0]
            data.append(link)
            imgSrc=re.findall(findImgSrc,item)[0]
            data.append(imgSrc)
            titles=re.findall(findTitle,item)
            if(len(titles)==2):
                ctitle=titles[0]
                data.append(ctitle)
                otitle=titles[1].replace("/","")
                data.append(otitle)
            else:
                data.append(titles[0])
                data.append('')
            rating=re.findall(findRating,item)[0]
            data.append(rating)
            judgeNum=re.findall(findJudge,item)[0]
            data.append(judgeNum)
            inq=re.findall(findInq,item)
            if len(inq)!=0:
                inq=inq[0].replace("。","")
                data.append(inq)
            else:
                data.append(" ")
            bd=re.findall(findBd,item)[0]
            bd=re.sub('<br(\s+)?/>(\s+)?'," ",bd)
            bd=re.sub('/'," ",bd)
            data.append(bd.strip())
            datalist.append(data)


    return datalist
def askURL(url):
    head = {
        "User-Agent": "Mozilla / 5.0(Windows NT 6.3;WOW64) AppleWebKit / 537.36(KHTML, likeGecko) Chrome / 70.03538.25Safari / 537.36Core / 1.70.3756.400QQBrowser / 10.5.4039.400"
    }
    request=urllib.request.Request(url, headers=head)
    html=""
    try:
        response = urllib.request.urlopen(request)
        html = response.read().decode("utf-8")

    except urllib.error.URLError as e:
        if hasattr(e, "code"):
            print(e.code)
        if hasattr(e, "reason"):
            print(e.reason)
    return html

def saveData(datalist,savepath):
    book=xlwt.Workbook(encoding="utf-8",style_compression=0)
    sheet=book.add_sheet('豆瓣电影Top250',cell_overwrite_ok=True)
    col=('电影详情连接','图片链接','影片中文名','影片外国名','评分','评价数','概况','相关信息')
    for i in range(0,8):
        sheet.write(0,i,col[i])
    for i in range(0,250):
        #print("第%d条"%(i+1))
        data=datalist[i]
        for j in range(0,8):
            sheet.write(i+1,j,data[j])
    book.save(savepath)
def saveData2DB(datalist,dbpath):
    init_db(dbpath)
    conn=sqlite3.connect(dbpath)
    cur=conn.cursor()
    for data in datalist:
        for index in range(len(data)):
            if index==4 or index==5:
                continue
            data[index]='"'+data[index]+'"'
        sql='''
                insert into movie250(
                info_link,pic_link,cname,ename,score,rated,instroduction ,info)
                values(%s)'''%",".join(data)
        cur.execute(sql)
        conn.commit()
    cur.close()
    conn.close()



def init_db(dbpath):
    sql='''
        create table movie250
        (
        id integer primary key autoincrement,
        info_link text,
        pic_link text,
        cname varchar,
        ename varchar,
        score numeric,
        rated numeric,
        instroduction text,
        info text
        )
    '''
    conn=sqlite3.connect(dbpath)
    cursor=conn.cursor()
    cursor.execute(sql)
    conn.commit()
    conn.close()
if __name__=="__main__":   #函数执行时
#调用函数
    main()
    #init_db("movietest.db")