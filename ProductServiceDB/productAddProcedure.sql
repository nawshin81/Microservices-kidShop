use productservice;
drop procedure if exists productAdd;
create procedure productAdd(
IN guid varchar(36),
IN name varchar(100),
IN categoryId varchar(36),
OUT output varchar(5)
)
begin
    set @checkname =
        (select count(name) from product where product.name = name);
    if @checkname=1 then
        set output='YES';
    else
        set output='NO';
    set @categoryname =
        (select categoryName from category where category.categoryId = categoryId );
    INSERT INTO product(id, name, categoryId, categoryName) VALUES
    (guid,name,categoryId,@categoryname);
    end if ;
end;

