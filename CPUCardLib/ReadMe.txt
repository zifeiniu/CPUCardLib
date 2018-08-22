  

 CPUCardWrapper 静态类，默认使用德卡D3 读卡器

 //删除文件
 CPUCardWrapper.DeleteFile(ushort fileID)

 //创建文件
 CPUCardWrapper.CreateFile(ushort fileID, string content, out string msg)

//读取文件
 CPUCardWrapper.ReadFile(ushort fileID, out string contentOrMsg)
