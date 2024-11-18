import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-claims-demo',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './claims-demo.component.html',
  styleUrl: './claims-demo.component.scss'
})
export class ClaimsDemoComponent {

  tab = "";

  form = this.fb.group({
    Name: ['', Validators.required],
    Value: ['', Validators.required]
  })
  
  constructor(private readonly fb: FormBuilder){

  }

  setTab(tab: string){
    this.tab = tab;
  }

  addFromClient(){
    
  }

  removeFromClient(){

  }

}
