#-*- codeing = utf-8 -*-
#@Time :2020/5/20 18:04
#@Author : 李康迪
#@File : testCloud.py
#@Software： PyCharm
import jieba
from matplotlib import pyplot as plt
from wordcloud import WordCloud
from PIL import Image
import numpy as np
import sqlite3
con=sqlite3.connect('movie.db')
cur=con.cursor()
sql='select instroduction from movie250'
data=cur.execute(sql)
text=""
for item in data:
    text=text+item[0]
cur.close()
con.close()

cut=jieba.cut(text)
string=' '.join(cut)

img=Image.open(r'.\static\assets\img\team\tree.jpg')
img_array=np.array(img)
wc=WordCloud(
    background_color='white',
    mask=img_array,
    font_path="msyh.ttc"
)
wc.generate_from_text(string)
fig=plt.figure(1)
plt.imshow(wc)
plt.axis('off')
plt.savefig(r'.\static\assets\img\tree.jpg',dpi=500)