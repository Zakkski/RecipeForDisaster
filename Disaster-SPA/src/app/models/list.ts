import { Ingredient } from './ingredient';

export interface List {
    id: number;
    name: string;
    isRecipe: boolean;
    ingredients: Ingredient[];
}