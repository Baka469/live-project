#!/usr/bin/python3
# -*- coding: UTF-8 -*-
import re
import datetime
import matplotlib.pyplot as plt
import jieba
from wordcloud import WordCloud,STOPWORDS
import seaborn as sns
from PIL import Image
import numpy as np
import matplotlib as mpl
import tkinter as tk
from tkinter import filedialog

def get_time(data):
	times = re.findall(r'\d+:\d{2}:\d{2}',data)#匹配时间
	hours = [time.split(":")[0] for time in times]#对每一个time分割出代表小时的那部分

	plt.subplot(111)
	#因为qq消息导出格式里，小时0-9是以个位形式出现，所以用个位的来对应
	sns.countplot(hours,order=['6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23','0','1','2','3','4','5'])
	plt.title("统计发言数(时)")
	plt.savefig("timesAnalysis.png")
	plt.cla()

def get_date(data):
	dates = re.findall(r'\d{4}-\d{2}-\d{2}',data)#匹配发言日期
	days = [date[-2:] for date in dates]#截取日
	plt.subplot(111)
	sns.countplot(days)#days就是数据集，countplot统计days每一天的重复数量就是每一天聊天数目
	plt.title('统计发言数(日)')
	plt.savefig("daysAnalysis.png")
	plt.cla()

def get_week(data):
	dates = re.findall(r'\d{4}-\d{2}-\d{2}',data)#匹配发言日期
	weekdays = [datetime.date(int(date[:4]),int(date[5:7]),int(date[-2:])).isocalendar()[-1]  for date in dates]
	plt.subplot(111)
	sns.countplot(weekdays)
	plt.title('统计发言数(星期)')
	plt.savefig("weekdaysAnalysis.png")
	plt.cla()

#词云制作
def get_wordcloud(data):
	word_list=[]
	for word in data:
		s=''.join(jieba.cut(word))
		word_list.append(s)
	new_text = ' '.join(word_list)
	plt.subplot(111)
	pic=Image.open('qie.jpg')
	my_mask=np.array(pic)
	wordcloud = WordCloud(
		background_color="white",
		font_path = 'simfang.ttf',
		mask=my_mask,
		stopwords = STOPWORDS,).generate(new_text)
	plt.imshow(wordcloud)
	plt.axis('off')#不显示坐标轴
	plt.title('词云图')
	plt.savefig("wordCloud.png")
	plt.cla()
	
def get_content(data):
	pa = re.compile(r'\d{4}-\d{2}-\d{2}.*?\d+:\d{2}:\d{2}.*?\n(.*?)\n',re.DOTALL)
	content = re.findall(pa,data)
	get_wordcloud(content)

def main():
	mpl.rcParams['font.sans-serif']=['SimHei']
	root = tk.Tk()
	root.withdraw()
	filename = filedialog.askopenfilename()
	with open(filename,encoding="UTF-8") as f:
		data = f.read()
	get_time(data)
	get_date(data)
	get_week(data)
	get_content(data)
	
if __name__ == '__main__':
	main()