use productservice;
drop procedure  if exists categoryUpdate;
create procedure  categoryUpdate(
IN productId varchar(36),
IN categoryId varchar(36)
)
begin
    set @catName=(select categoryName from category where category.categoryId=categoryId);
    update product
        set product.categoryId=categoryId,
            product.categoryName=@catName
        where product.id=productId;
end;
call categoryUpdate('d30109c9-c98f-4580-8239-288a2ff3f634','847435b4-125c-4bfc-9d03-9832b3aacd64');
