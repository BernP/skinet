import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent implements OnInit {
  baseUrl =environment.apiUrl;
  validationErrors: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }
  get404Error(){
    this.http.get(this.baseUrl + 'api/products/55').subscribe(r =>{
      console.log(r);
    }, error => {
      console.log(error)
    });
  }
  get500Error(){
    this.http.get(this.baseUrl + 'api/buggy/servererror').subscribe(r =>{
      console.log(r);
    }, error => {
      console.log(error)
    });
  }
  get400Error(){
    this.http.get(this.baseUrl + 'api/buggy/badrequest').subscribe(r =>{
      console.log(r);
    }, error => {
      console.log(error)
    });
  }
  get400ValidationError(){
    this.http.get(this.baseUrl + 'api/products/fortytow').subscribe(r =>{
      console.log(r);
    }, error => {
      console.log(error);
      this.validationErrors = error.errors;
    });
  }

}
