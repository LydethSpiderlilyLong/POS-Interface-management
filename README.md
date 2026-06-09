Team Members:
1. Long Momthalydeth
2. Soung Khamakporttea
3. Seng Mouychheng
4. Prich Vanliza
5. Hab Kanhchana
6. Heng Sreynich
7. Ly Thongpich
8. Chou Chhayhong
9. Thoem Chantha
10. Pov Borom

  —————————POS System——————————
Structure:
> LogInForm
  > DashboardForm
    > User
    > Role
    > Product
    > Supplier
    > Categories

====================================
  
+ User
	- id p.k
	- userName
	-gender
	-password
	-email
	-status
+ Role
	-id p.k
	-RoleName
	-Status
+ Product
	-id p.k
	-Name unique
	-Barcode unique
	-sellPrice
	-Photo(Optional)
+ Category
	-id p.k
	-Name unique
	-status
+ Supplier
	-id p.k
	-Name
	-Tel
  

 
