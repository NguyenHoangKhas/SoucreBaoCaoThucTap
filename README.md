"# source.erp.ntt" 
1. Check file data.txt
2. Source tham khảo khi có bug có thể comment lại.
3. khi code tuyệt đối KHÔNG code trên nhánh main, bạn nào code tự tạo nhánh riêng mà code.
3. lưu ý kiểu datetime lưu dạng unix timestamp (kiểu int)
4. thực hiện task cho các thực thể mới
Nhóm 1 ngày 10-14/11/2025
 hrm_attendance
   attendance_id int PK not null
   employee_id int FK not null
   check_date datetime
   leave_id int default=0
   is_actived int, default=0
 
 hrm_attendance_his 
  attendance_id_his int PK not null 
  attendance_id int FK not null
  check_in_time datetime
  check_out_time datetime
  num_late	int
  num_early_leave	int
  working_minutes	Int
  is_actived int, default=0

Nhóm 2 ngày 10-14/11/2025
 
 hrm_leave_types
  leave_types_id int PK
  types_name nvarchar(100)
  is_paid bool 
  is_actived int, default=1

 hrm_leave_requests
  leave_id int PK
  employee_id int FK
  request_date datetime
  leave_type_id int 
  start_date datetime 
  end_date datetime 
  leave_count int 
  leave_mode int  
  reason VARCHAR(255) 
  reviewe_date datetime
  reviewer_id int 
  approver_date datetime
  approver_id int 
  approver_date datetime
  hr_confirm_id int
  hr_confirm_date datetime
  is_actived int 

Nhóm 6 ngày 10-14/11/2025
 hrm_holidays
  holiday_id int PK notnull
  holiday_date datetime notnull    
  description	VARCHAR(255)        
  is_actived int, default=1