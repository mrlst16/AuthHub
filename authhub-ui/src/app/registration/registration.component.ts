import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {

  form = this.formBuilder.group({
    Name: ['', Validators.required]
  })

  constructor(
    private readonly formBuilder: FormBuilder
  ){
    
  }

  onSubmit(){
    console.log(this.form)
  }
}
