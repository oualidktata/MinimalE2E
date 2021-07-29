import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AngularMaterialModule } from './material/material.module';

const declarationsToExport: any[] = [];

const localDeclarations: any[] = [];

const importsToExport = [
  CommonModule,
  FormsModule,
  AngularMaterialModule,
  ReactiveFormsModule,
  RouterModule,
];

const localImports: any[] = [];

@NgModule({
  declarations: [...localDeclarations, ...declarationsToExport],
  exports: [...declarationsToExport, ...importsToExport],
  imports: [...localImports, ...importsToExport],
})
export class SharedModule { }
