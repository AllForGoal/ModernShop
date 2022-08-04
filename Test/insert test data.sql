use EcommerceSystem
insert into categories(Name,ParentId)
select 'women',null
union all select 'men',null
union all select 'clothes',1
union all select 'clothes',2
 
insert into brands(Name)
select 'townteam'
union all select 'gucci'
union all select 'zara' 
union all select 'addidas' 

insert into products(Name,Description,Rate,BrandId,CategoryId)
select 't shirt',' dfgk gklfggj',0,1,1
union all select ' shirt',' dfgk gklfggj',0,1,2
union all select 'pants',' dfgk gklfggj',0,2,1



