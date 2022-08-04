use productservice;

drop procedure if exists ratingUpdate;
create procedure ratingUpdate
(
IN productId varchar(36),
IN avgRate float,
IN numOfRaters int
)
BEGIN
    update product
        set product.averageRating=avgRate and
                                  product.numberOfRaters=numOfRaters
    where product.id=productId;
end;