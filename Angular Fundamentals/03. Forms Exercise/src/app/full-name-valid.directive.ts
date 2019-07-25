import { Directive } from '@angular/core';
import { AbstractControl, ValidatorFn, Validator, ValidationErrors, NG_VALIDATORS } from '@angular/forms';

@Directive({
  selector: '[appFullNameValid]',
  providers: [
    { provide: NG_VALIDATORS, useExisting: FullNameValidDirective, multi: true }
  ]
})

export class FullNameValidDirective implements Validator {
  validator: ValidatorFn;

  constructor() {
    this.validator = this.fullNameValidate();
  }

  validate(control: AbstractControl): ValidationErrors {
    return this.validator(control);
  }

  fullNameValidate(): ValidatorFn {
    return (fullName: AbstractControl) => {
      let invalidObj = {
        fullNameInvalid: {
          valid: false
        }
      };

      let value = fullName.value;

      if (!value) {
        return null;
      }

      if (value && value.split(" ").filter(x => x).length == 2 && 
          this.ifAllWordsStartedWithCapitalLetter(value.split(" "))) {
        return null;
      }

      return invalidObj;
    }
  }

  private ifAllWordsStartedWithCapitalLetter(names: Array<string>) : boolean {
    return names[0][0].toUpperCase() === names[0][0] &&
           names[1][0].toUpperCase() === names[1][0];
  }
}
