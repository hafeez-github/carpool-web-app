import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  
  constructor(private router:Router) {
    
  }
  canActivate():boolean{
    if(localStorage.getItem('token')!=null){
      return true;
    }
    else{
      this.router.navigate(['/auth/login']);
      return false;
    }
    
  }
  
}
