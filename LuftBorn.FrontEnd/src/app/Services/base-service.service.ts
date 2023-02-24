import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgxToastNotifyService } from 'ngx-toast-notify';
import { EMPTY } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BaseServiceService {

  protected serviceBase: string = ''
  constructor(public toastr: NgxToastNotifyService) {
  }
  handleError(errorResponse: any) {
    let message: string = "";
    if (errorResponse instanceof HttpErrorResponse) {
      if (errorResponse?.error?.detail) {
        message = errorResponse?.error?.detail;
      } else if (errorResponse?.error?.errors) {
        for (let key in errorResponse?.error?.errors) {
          for (let value in errorResponse?.error?.errors[key])
            message += errorResponse?.error?.errors[key][value] + "\n";
        }
      } else {
        message = 'Something happened  away from you it’s okay it’s not your fault';
      }
    } else {
      message = 'Something happened away from you it’s okay it’s not your fault';
    }
    this.toastr.showToast(message, 'danger', 'top-center');
    return EMPTY;
  }
}
