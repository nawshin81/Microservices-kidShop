use productService;

insert into product (id,name, categoryId,categoryName) values
    ('d30109c9-c98f-4580-8239-288a2ff3f634','light ball', '847435b4-125c-4bfc-9d03-9832b3aacd64','toys'),
    ('cb6dd014-2058-433d-b964-9695713a4c0e','blocks', '847435b4-125c-4bfc-9d03-9832b3aacd64','toys'),
    ('10747dbb-1165-4da6-b471-75ca6c7ece8c','cool red shirt', '1750f245-cb4d-4234-9a89-ff557e38edbc','cloths'),
    ('7bbb5db0-1ce8-4a7d-91a6-4cdefc8c9d5c','long blue skirt', '1750f245-cb4d-4234-9a89-ff557e38edbc','cloths'),
    ('667a7a30-9c94-4c2f-af24-71525b4889e1','nice green pants', '1750f245-cb4d-4234-9a89-ff557e38edbc','cloths'),
    ('1f7d5f76-6f88-48ec-be43-d529ac16c326','kids comfi', '48ad79f4-a9da-412e-8fba-589d9b6b6d91','diaper');

insert into category (categoryId,categoryName) values
    ('847435b4-125c-4bfc-9d03-9832b3aacd64','toys'),
    ('1750f245-cb4d-4234-9a89-ff557e38edbc','cloths'),
    ('48ad79f4-a9da-412e-8fba-589d9b6b6d91','diaper');