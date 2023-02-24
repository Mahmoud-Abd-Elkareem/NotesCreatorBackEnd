import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxToastNotifyService } from 'ngx-toast-notify';
import { Observable, Subscription } from 'rxjs';
import { NoteServiceService } from 'src/app/Services/note-service.service';
import { NoteListObj, NoteModel } from '../Model/note-model';

@Component({
  selector: 'app-note-list',
  templateUrl: './note-list.component.html',
  styleUrls: ['./note-list.component.css']
})
export class NoteListComponent implements OnInit {
  notesList : NoteListObj[] = []
  private eventsSubscription: Subscription;
  NoteForm : FormGroup ;
  NoteEditForm : FormGroup;
  NoteObj : NoteModel ={
    nameAr:'',
    nameEn:'',
    descriptionAr:'',
    descriptionEn:''
  };
  @Input() events: Observable<void>;
  constructor(public noteService : NoteServiceService , public route : Router,public toastr: NgxToastNotifyService) { }

  ngOnInit(): void {
    this.eventsSubscription = this.events.subscribe(() => this.getNoteSList());
    this.getNoteSList()
    this.intiateNoteForm()

  }
  intiateNoteForm(){
    this.NoteForm = new FormGroup({
      NameAr : new FormControl(this.NoteObj.nameAr, [Validators.required]),
      NameEn : new FormControl(this.NoteObj.nameEn, [Validators.required]),
      DescriptionAr : new FormControl(this.NoteObj.descriptionAr, [Validators.required]),
      DescriptionEn : new FormControl(this.NoteObj.descriptionEn, [Validators.required])
    })
  }
  getNoteSList(){
    this.notesList = []
    this.noteService.NotesService$().subscribe(
      res=>{
        res.data.items.forEach(item=>this.notesList.push(item))
      }
    )
  }
  deleteNote(id:string){
    this.noteService.DeleteNoteService$(id).subscribe(
      res=>{
        if(res.succeeded){
          this.getNoteSList()
          this.toastr.showToast('Deleted Successfully', 'success', 'top-center');
        }
      }
    )
  }
  navigatetoDetails(id:string){
    localStorage.setItem('id', id);
      this.route.navigateByUrl(`Details`)
  }
  ngOnDestroy() {
    this.eventsSubscription.unsubscribe();
  }

  EditNote(id:string){
    this.NoteObj = {
      id:id,
      nameAr : this.NoteForm.value.NameAr,
      nameEn : this.NoteForm.value.NameEn,
      descriptionAr : this.NoteForm.value.DescriptionAr,
      descriptionEn : this.NoteForm.value.DescriptionEn
    }
    this.noteService.EditNotesService$(this.NoteObj).subscribe(res=>{
      if(res.succeeded){
        this.getNoteSList()
        this.toastr.showToast('Edited Successfully', 'success', 'top-center');
      }

    })
  }
  getNote(id:string){
    this.noteService.getNoteService$(id).subscribe(
      res=>{
        if(res.succeeded){
          this.NoteObj = res.data
          this. intiateNoteForm()
        }
      }
    )
  }
}
