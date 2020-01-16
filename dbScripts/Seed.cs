// // Delete Ingredients
// Ingredients.DeleteAllOnSubmit(Ingredients);
// SubmitChanges();
// ListItems.DeleteAllOnSubmit(ListItems);
// SubmitChanges();
// UserLists.DeleteAllOnSubmit(UserLists);
// SubmitChanges();
// Lists.DeleteAllOnSubmit(Lists);
// SubmitChanges();



// // Create Ingredients
// Ingredients ing1 = new Ingredients()
// {
//     Name = "Lemon",
//     Count = true
// };
// Ingredients.InsertOnSubmit(ing1 );
// Ingredients ing2 = new Ingredients()
// {
//     Name = "Milk",
//     Count = false
// };
// Ingredients.InsertOnSubmit(ing2 );
// Ingredients ing3 = new Ingredients()
// {
//     Name = "Sour Cream",
//     Count = false
// };
// Ingredients.InsertOnSubmit(ing3 );
// Ingredients ing4 = new Ingredients()
// {
//     Name = "Butter",
//     Count = false
// };
// Ingredients.InsertOnSubmit(ing4 );
// Ingredients ing5 = new Ingredients()
// {
//     Name = "Onion",
//     Count = true
// };
// Ingredients.InsertOnSubmit(ing5 );
// Ingredients ing6 = new Ingredients()
// {
//     Name = "Orange",
//     Count = true
// };
// Ingredients.InsertOnSubmit(ing6 );
// Ingredients ing7 = new Ingredients()
// {
//     Name = "Thyme",
//     Count = true
// };
// Ingredients.InsertOnSubmit(ing7 );
// SubmitChanges();

// // Create Lists
// Lists list1 = new Lists()
// {
//     Name = "Delicious Meal",
//     IsRecipe = true,
//     CreatorId = 3
// };
// Lists.InsertOnSubmit(list1 );
// Lists list2 = new Lists()
// {
//     Name = "Main Shopping List",
//     IsRecipe = false,
//     CreatorId = 3
// };
// Lists.InsertOnSubmit(list2 );
// SubmitChanges();

// // Create ListItems
// ListItems li1 = new ListItems()
// {
//     Amount = 2,
//     ListId = list1.Id,
//     IngredientId = ing1.Id
// };
// ListItems.InsertOnSubmit(li1 );
// ListItems li2 = new ListItems()
// {
//     Amount = 8,
//     ListId = list1.Id,
//     IngredientId = ing2.Id
// };
// ListItems.InsertOnSubmit(li2 );
// ListItems li3 = new ListItems()
// {
//     Amount = 4,
//     ListId = list1.Id,
//     IngredientId = ing3.Id
// };
// ListItems.InsertOnSubmit(li3 );
// ListItems li4 = new ListItems()
// {
//     Amount = 12,
//     ListId = list1.Id,
//     IngredientId = ing4.Id
// };
// ListItems.InsertOnSubmit(li4 );
// ListItems li5 = new ListItems()
// {
//     Amount = 1,
//     ListId = list1.Id,
//     IngredientId = ing5.Id
// };
// ListItems.InsertOnSubmit(li5 );
// ListItems li6 = new ListItems()
// {
//     Amount = 2,
//     ListId = list2.Id,
//     IngredientId = ing1.Id
// };
// ListItems.InsertOnSubmit(li6 );
// ListItems li7 = new ListItems()
// {
//     Amount = 8,
//     ListId = list2.Id,
//     IngredientId = ing2.Id
// };
// ListItems.InsertOnSubmit(li7 );
// ListItems li8 = new ListItems()
// {
//     Amount = 4,
//     ListId = list2.Id,
//     IngredientId = ing3.Id
// };
// ListItems.InsertOnSubmit(li8 );
// ListItems li9 = new ListItems()
// {
//     Amount = 12,
//     ListId = list2.Id,
//     IngredientId = ing4.Id
// };
// ListItems.InsertOnSubmit(li9 );
// ListItems li10 = new ListItems()
// {
//     Amount = 1,
//     ListId = list2.Id,
//     IngredientId = ing5.Id
// };
// ListItems.InsertOnSubmit(li10 );
// SubmitChanges();

// UserLists userList1 = new UserLists()
// {
//     UserId = 3,
//     ListId = list1.Id
// };
// UserLists.InsertOnSubmit(userList1 );
// UserLists userList2 = new UserLists()
// {
//     UserId = 3,
//     ListId = list2.Id
// };
// UserLists.InsertOnSubmit(userList2 );
// SubmitChanges();

// // Display Tables
// Ingredients.Dump();
// Lists.Dump();
// ListItems.Dump();
// UserLists.Dump();
