import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NoteHomeComponent } from './Modules/Notes/note-home/note-home.component';
import { RouterModule, Routes } from '@angular/router';
import { NoteDetailsComponent } from './Modules/Notes/note-details/note-details.component';


const routes : Routes =[
  {
    path:'',
    component:NoteHomeComponent
  },
  {
    path:'Details',
    component:NoteDetailsComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
