import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RecipeComponent } from './recipe/recipe.component';
import { ShoppingListComponent } from './shopping-list/shopping-list.component';
import { AdminComponent } from './admin/admin.component';

export const appRoutes: Routes = [
    { path: '', component: DashboardComponent},
    { path: 'admin', component: AdminComponent},
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
