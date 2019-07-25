import { Directive, ElementRef, HostListener, Renderer2 } from '@angular/core';
import { NgForm } from '@angular/forms';

@Directive({
  selector: '[appImgValidation]'
})
export class ImgValidationDirective {

  constructor(private elementRef : ElementRef, private form: NgForm, private renderer: Renderer2) { 

  }

  @HostListener('input')
  inputHandler() {
    let imgInput = this.elementRef.nativeElement;

    if (!imgInput.value) {
      this.form.controls["img"].setErrors(null);
      this.form.controls["img"].setErrors( {'required': true} );

      return;
    }

    if (imgInput && imgInput.value && imgInput.value.startsWith("http") &&
        (imgInput.value.endsWith("jpg") || imgInput.value.endsWith("png"))) {
          this.form.controls["img"].setErrors(null);

    } else {
      this.form.controls["img"].setErrors({'incorrect': true });
    }
  }
}
