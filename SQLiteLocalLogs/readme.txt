Nuget package: System.Data.SQLite

Cấu trúc chương trình:
File: DBUtils.cs gồm 2 class DBUtils và Log
- Class: Log
	+ ShowLog()
- Class: DBUtils
	+ DBUtils():
	+ AddLog(transID, transDate): 	thêm log mới vào db.
	+ DeleteOldLog(): 		tự động xóa các log cũ hơn 15 ngày, tự động gọi khi sang ngày mới.
	+ IsDoubleTransID(transID): 	kiểm tra nếu cơ sở dữ liệu tồn tại 2 transID giống nhau trong cùng 1 ngày.
	+ SearchLog(transID, transDate):tìm kiếm log.
	+ SelectLog():			truy vấn xem toàn bộ log.

Vị trí file db.sqlite: SQLiteLocalLogs\SQLiteLocalLogs\bin\Debug\netcoreapp3.1\db.sqlite
Chương trình quản lý database sqlite: DB Browser for SQLite