import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ImgValidationDirective } from '../img-validation.directive';

@Component({
  selector: 'app-register-form-reactive',
  templateUrl: './register-form-reactive.component.html',
  styleUrls: ['./register-form-reactive.component.css']
})
export class RegisterFormReactiveComponent implements OnInit {
  public register: FormGroup;
  public startsPhones: Array<string>;
  public proffessions: Array<string>;

  constructor() { 
    this.startsPhones = this.getStartedPhones();
    this.proffessions = this.getProffesions();
    this.register = new FormGroup({
      fullName: new FormControl("", [Validators.pattern('^[A-Z][a-z]+ [A-Z][a-z]+$'), Validators.required]),
      email: new FormControl("", [Validators.pattern('^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$'), Validators.required]),
      phone: new FormControl("", [Validators.required, Validators.pattern('^[0-9]{9}$')]),
      startPhone: new FormControl(this.startsPhones[0]),
      proffession: new FormControl(this.proffessions[0]),
      passwords: new FormGroup({
        password: new FormControl("", [Validators.required, Validators.pattern("^[a-zA-Z0-9]{3,16}$")]),
        repeatePassword: new FormControl("", [Validators.required])
      }),
      image: new FormControl("", [Validators.required])
    })
  }

  get name() { return this.register.get('fullName'); }

  get email() { return this.register.get('email'); }

  get phone() { return this.register.get('phone'); }

  get password() { return this.register.get('passwords').get('password'); }

  get repeatePass() { return this.register.get('passwords').get('repeatePassword'); }
  
  get img() { return this.register.get('image'); }

  private getProffesions() {
    return [
      "Designer",
      "Manager",
      "Accounting"
    ]
  }

  private getStartedPhones() {
    return [
      "+971",
      "+359",
      "+972",
      "+198",
      "+701"
      ];
  }

  ngOnInit() {
  }

  onSubmit() {
      this.register.reset({
        startPhone: this.startsPhones[0],
        proffession: this.proffessions[0],
      }
    );
  }
}
