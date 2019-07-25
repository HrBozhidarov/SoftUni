import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @ViewChild("form", { static: false })
  public registerForm: NgForm;

  public startNumbers: Array<string>;
  public proffesions: Array<string>;
  public defaultNumberStart: string;
  public defaultProffesion: string;

  constructor() {
    this.startNumbers = ["+971", "+359", "+972", "+198", "+701"];
    this.proffesions = ["Designer", "Manager", "Accounting"];
    this.defaultNumberStart = this.startNumbers[0];
    this.defaultProffesion = this.proffesions[0];
  }

  ngOnInit() {
  }

  register() {
    this.resetDefaultValuesInRegisterForm();
  }

  private resetDefaultValuesInRegisterForm() {
    this.registerForm.reset({ 
            startPhone: this.defaultNumberStart,
            proffesion: this.defaultProffesion,
            phoneNumber: "",
            email: "",
            fullName: "",
            pass: "",
            repeatePass: "",
            img: ""
          });
  }
}
