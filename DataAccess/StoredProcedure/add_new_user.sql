alter PROCEDURE add_new_user
    @Email nvarchar(64),
    @Password nvarchar(20)
AS
BEGIN
    if exists (select 1
    from [user]
    where email = @Email)
    THROW 50001, 'Email address already exists', 1;

insert into [user]
    (id, email, password)
values
    (newid(), @Email, @Password);
return 1
END;

EXEC add_new_user @Email = 'test2@email.com', @Password = '123456';