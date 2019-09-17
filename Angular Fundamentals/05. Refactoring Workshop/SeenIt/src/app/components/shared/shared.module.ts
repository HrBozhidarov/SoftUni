import { NgModule } from '@angular/core';
import { ContentComponent } from './content/content.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@NgModule({
    declarations: [
        ContentComponent,
        FooterComponent,
        HeaderComponent,
        NavigationComponent
    ],
    imports: [
        // FormsModule,
        CommonModule,
        RouterModule
    ],
    exports: [
        ContentComponent,
        FooterComponent,
        HeaderComponent
    ],
    providers: []
})
export class SharedModule {

}