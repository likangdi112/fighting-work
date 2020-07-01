#-*- codeing = utf-8 -*-
#@Time :2020/6/12 22:41
#@Author : 李康迪
#@File : sentimentscore.py
#@Software： PyCharm
# -*- coding: utf-8 -*-
from snownlp import SnowNLP
import codecs
import os

source = open("totalcomment.txt","r", encoding='utf-8')
line = source.readlines()
sentimentslist = []
m=0 #判断评论总数
for i in line:
    if(len(i)>0 and m<500):#看前500条频率,消去空行
        m=m+1
        s = SnowNLP(i)

        sentimentslist.append(s.sentiments)

import matplotlib.pyplot as plt
import numpy as np
plt.plot(np.arange(0,m, 1), sentimentslist, 'k-')
plt.xlabel('Number')
plt.ylabel('Sentiment')
plt.title('Analysis of Sentiments')
plt.savefig(r'.\sentimentsscore.jpg',dpi=500)
plt.show()
