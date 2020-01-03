# RecipeForDisaster
An application that allows users to store information about food that they have so they can make better and less wasteful store purchases


User
---
UserId PK int
Name varchar(200)
Email UNIQUE varchar(200)
Password varchar(200)

UserList
---
UserListId PK int
UserId int FK >- User.UserId
ListId int FK >- List.ListId

List
---
ListId PK int
CreatorId int FK >- User.UserId
IsRecipe bool


ListItem
---
ListItemId PK int
ListId int FK >- List.ListId
IngredientId int FK >- Ingredient.IngredientId
Amount int

Ingredient
---
IngredientId PK int
Name varchar(200)
Count bool
