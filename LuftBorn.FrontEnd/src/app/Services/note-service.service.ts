import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxToastNotifyService } from 'ngx-toast-notify';

import { catchError } from 'rxjs';
import { AppRestResponse, NoteListObj, NoteModel, PagedItems } from '../Modules/Notes/Model/note-model';
import { BaseServiceService } from './base-service.service';

@Injectable({
  providedIn: 'root'
})
export class NoteServiceService extends BaseServiceService {

  constructor(public http: HttpClient ,public override toastr: NgxToastNotifyService) {
    super(toastr)
}
NotesService$ = () => {
  let noteURL = `https://localhost:7288/api/v1/Note?pageIndex=0&pageSize=23`
  return this.http.get<AppRestResponse<PagedItems<NoteListObj>>>(noteURL).pipe(
    catchError((err) => this.handleError(err))

  )}
  AddNotesService$ = (noteObj : NoteModel) => {
    let noteURL = `https://localhost:7288/api/v1/Note`
    return this.http.post<AppRestResponse<NoteModel>>(noteURL ,noteObj).pipe(
      catchError((err) => this.handleError(err))

    )}
    EditNotesService$ = (noteObj : NoteModel) => {
      let noteURL = `https://localhost:7288/api/v1/Note`
      return this.http.put<AppRestResponse<NoteModel>>(noteURL ,noteObj).pipe(
        catchError((err) => this.handleError(err))

      )}

  DeleteNoteService$ =(id :string) =>{
    let noteURL = `https://localhost:7288/api/v1/Note?id=`+id
    return this.http.delete<AppRestResponse<NoteModel>>(noteURL).pipe(
      catchError((err) => this.handleError(err)))
  }
  getNoteService$ =(id :string) =>{
    let noteURL = `https://localhost:7288/api/v1/Note/`+id
    return this.http.get<AppRestResponse<NoteModel>>(noteURL).pipe(
      catchError((err) => this.handleError(err)))
  }
}
