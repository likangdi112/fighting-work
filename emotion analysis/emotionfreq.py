#-*- codeing = utf-8 -*-
#@Time :2020/6/12 22:23
#@Author : 李康迪
#@File : emotionfreq.py
#@Software： PyCharm
# -*- coding: utf-8 -*-
from snownlp import SnowNLP
import codecs
import os

source = open("totalcomment.txt","r", encoding='utf-8')
line = source.readlines()
sentimentslist = []
for i in line:
    if(len(i)>0):#因为格式关系，有些行可能为空
        s = SnowNLP(i)
        #print(s.sentiments)
        sentimentslist.append(s.sentiments)

import matplotlib.pyplot as plt
import numpy as np
plt.hist(sentimentslist, bins = np.arange(0, 1, 0.01), facecolor = 'g')
plt.xlabel('sentiments Probability')
plt.ylabel('Quantity')
plt.title('Analysis of Sentiments')
plt.savefig(r'.\sentimentsfrq.jpg',dpi=500)
plt.show()
