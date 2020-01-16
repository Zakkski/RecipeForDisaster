import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RecipeComponent } from './recipe/recipe.component';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';

export const appRoutes: Routes = [
    { path: '', component: DashboardComponent},
    {
        path: 'recipes',
        children: [
            { path: ':id', component: RecipeComponent }
        ]
    },
    {
        path: 'shopping-lists',
        children: [
            { path: ':id', component: ShoppingListComponent }
        ]
    }
];
