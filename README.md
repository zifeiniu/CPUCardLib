
# 使用C# 对CPU卡基本操作封装

## 项目需求及简介：
公司要求将用户相关的信息储存到射频卡中，之前项目使用的Mifare类型卡，只储存了用户的卡ID。Mifare S70容量也不够，遂使用CPU卡，FM1280，可达80KB的EEROM存储。
在CSDN上花积分下载了一个C#读取CPU卡的Demo，恶心的是不仅没有源码，而且互操作调用封装的DLL，还指定使用他们的读卡器，打广告还带赚我积分的。。
然后自己写了一个，开源一下，供大家改改。。

# 介绍

已实现两种设备的接口
Pcsc，使用CAR122U读卡器（PcscCardReader）（https://github.com/danm-de/pcsc-sharp），只要实现PCSC驱动读卡器都可以使用。
德卡D3D8 读卡器 DeCardReader。（德卡的读卡器DLL貌似只有32位的）
添加新读卡器，只需要实现接口ICPUCardReader即可。接口很简单，只要实现发送byte[]，返回byte[]即可。

CpuCard类封常用操作命令。

目前只实现外部身份验证，没写秘钥操作相关。
创建二进制文件，写入文件，读取文件，记录日志等。


## 遇到的坑

#### 最大二进制文件：
文档没有说明二进制文件最大可用多少大。创建一个大的二进制文件时没有报错，但是写入时报错。
检查文档：当P1 参数的最高位不为1时，P1 P2 为欲写入的文件偏移量，也就是说最大偏移量为7FFF，32767个字节，使用Unicode编码，最多可写16383个汉字


#### 硬件资源释放问题：
像这种硬件读取完成的时候不知道什么时候释放资源合适，每次发送命令的时候打开，发送完成后关闭，这样不晓得慢是肯定了，而且可能会减少硬件寿命。
所以在设备层发送命令后不关闭，在卡操作业务层关闭。当下次发送命令时，自动检测设备未打开，则打开设备。

####  读取二进制文件问题：
因为写入的可以指定二进制文件的长度，但是读取二进制文件的时候，没找到如何获取二进制文件的长度。

发现读取会有提示如下
6Cxx 出错 Le长度错误，实际长度是xx。
则读取碰到6C后，修正此次读取数据长度，继续读取。



## 参考文件: 
 FMCOS专用技术手册 （使用复旦微电子的卡）


## 测试设备型号
ACR122U  德卡D8（即将实现）

## 测试CPU卡型号：
FM1216-137  FM1280

## 未实现功能
时间紧迫，目前没用使用加密，线路保护功能。

