#-*- codeing = utf-8 -*-
#@Time :2020/6/12 17:08
#@Author : 李康迪
#@File : cloud world.py
#@Software： PyCharm
from wordcloud import WordCloud
import matplotlib.pyplot as plt  # 绘制图像的模块
import jieba  # jieba分词
from collections import Counter
path_txt = 'hotcomment.txt'
f1 = open(path_txt, 'r', encoding='UTF-8').read()
path_txt = 'commoncomment.txt'
f2 = open(path_txt, 'r', encoding='UTF-8').read()
f=f1+f2
#结巴分词，生成字符串，wordcloud无法直接生成正确的中文词云
cut_text = " ".join(jieba.cut(f,HMM=True))
#cut_text = " ".join(jieba.cut(f1,HMM=True)) 热评分词
wordcloud = WordCloud(
    # 设置字体，不然会出现口字乱码，文字的路径是电脑的字体一般路径，可以换成别的
    font_path="msyh.ttc",
    # 设置了背景，宽高
    background_color="black", width=2000, height=880).generate(cut_text)
#词频统计
all_words=cut_text.split(" ")
c=Counter()
for (k,v) in c.most_common(10):
    print("%s:%d"%(k,v))
for x in all_words:
    if len(x) > 1 and x != '\r\n':
        c[x] += 1
 #统计前二十个出现频率最高的词
for (k,v) in c.most_common(20):
    print("%s:%d"%(k,v))
#写入txt文件
fw = open('hottop20.txt', 'w', encoding='utf-8')
i = 1
for (k,v) in c.most_common(20):
    fw.write(str(i)+','+str(k)+','+str(v)+'\n')
    i = i + 1
else:
    print("Over write file!")
    fw.close()
plt.imshow(wordcloud, interpolation="bilinear")
plt.axis("off")
plt.savefig(r'.\wuhanHMM.jpg',dpi=500)
#plt.savefig(r'.\wuhan1HMM.jpg',dpi=500)   热评词云图
plt.show()
