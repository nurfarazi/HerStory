import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TextInputComponent } from './components/text-input/text-input.component';

@NgModule({
    declarations: [
        TextInputComponent
    ],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
    exports: [
        PaginationModule,
        ReactiveFormsModule,
        FormsModule,
        BsDropdownModule,
        TextInputComponent,
    ]
})
export class SharedModule {
}
