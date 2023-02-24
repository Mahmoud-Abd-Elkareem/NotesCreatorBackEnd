import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxToastNotifyService } from 'ngx-toast-notify';
import { Subject } from 'rxjs';
import { NoteServiceService } from 'src/app/Services/note-service.service';
import { NoteModel } from '../Model/note-model';

@Component({
  selector: 'app-note-home',
  templateUrl: './note-home.component.html',
  styleUrls: ['./note-home.component.css']
})
export class NoteHomeComponent implements OnInit {
  @ViewChild('content') myModal: any;
  NoteForm : FormGroup ;
  NoteObj : NoteModel ={
    nameAr:'',
    nameEn:'',
    descriptionAr:'',
    descriptionEn:''
  };
  eventsSubject: Subject<void> = new Subject<void>();
  constructor(public noteService : NoteServiceService,public toastr: NgxToastNotifyService) { }

  ngOnInit(): void {
    this.intiateNoteForm()
  }

  intiateNoteForm(){
    this.NoteForm = new FormGroup({
      NameAr : new FormControl('', [Validators.required]),
      NameEn : new FormControl('', [Validators.required]),
      DescriptionAr : new FormControl('', [Validators.required]),
      DescriptionEn : new FormControl('', [Validators.required])
    })
  }
  AddNote(){
    this.NoteObj = {
      nameAr : this.NoteForm.value.NameAr,
      nameEn : this.NoteForm.value.NameEn,
      descriptionAr : this.NoteForm.value.DescriptionAr,
      descriptionEn : this.NoteForm.value.DescriptionEn
    }
    this.noteService.AddNotesService$(this.NoteObj).subscribe(res=>{
      if (res.succeeded) {
      this.eventsSubject.next();
        this.toastr.showToast('Added Successfully', 'success', 'top-center');
      }

    })
    this.intiateNoteForm()
  }
  EditFunc(event : any){
    this.noteService.getNoteService$(event).subscribe(
      res=>{
        this.NoteObj = res.data
        this.intiateNoteForm()
      }
    )

  }
}
