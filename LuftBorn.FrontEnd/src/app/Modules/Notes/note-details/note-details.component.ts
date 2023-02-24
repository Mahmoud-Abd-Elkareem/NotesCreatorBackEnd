import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoteServiceService } from 'src/app/Services/note-service.service';
import { NoteModel } from '../Model/note-model';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrls: ['./note-details.component.css']
})
export class NoteDetailsComponent implements OnInit {

  NoteId : string
  NoteObj : NoteModel

  constructor(private activatedRoute: Router , public noteService : NoteServiceService) { }

  ngOnInit(): void {
    let params: any = localStorage.getItem('id');
    this.NoteId =params
    this.getNoteDetails(this.NoteId)


  }

  getNoteDetails(id:string){
    this.noteService.getNoteService$(id).subscribe(
      res=>{
        if(res.succeeded){
          this.NoteObj = res.data

        }
      }
    )
  }
  navigateToHome(){
    this.activatedRoute.navigateByUrl('')
  }
}
