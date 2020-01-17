import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
    ingredientForm: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

    ngOnInit() {
        this.ingredientForm = this.fb.group({
            ingredients: this.fb.array([this.createIngredient()])
        });
    }

    get ingredients() {
        return this.ingredientForm.get('ingredients') as FormArray;
    }

    createIngredient(): FormGroup {
        return this.fb.group({
            name: '',
            count: ''
        });
    }

    addIngredient() {
        this.ingredients.push(this.createIngredient());
        console.log(this.ingredientForm);
    }

    onSubmit() {
        this.formatCheckboxes();
        this.http.post('http://localhost:5000/api/ingredients', this.ingredientForm.value.ingredients).subscribe();
        this.ingredientForm.reset();
    }

    formatCheckboxes() {
        this.ingredientForm.value.ingredients.forEach(ingredient => {
            ingredient.count = ingredient.count === true;
        });
    }

}
