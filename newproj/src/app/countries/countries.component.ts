import { Component, OnInit ,Input} from '@angular/core';
import {  HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SafeMethodCall } from '@angular/compiler';



@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.css']
})


export class CountriesComponent  {
 
 /* constructor(private http : HttpClient) { }
  rows : any;
  ngOnInit(): void {
    debugger
    this.http.get("http://localhost:5000/countries").subscribe(rows=>{
      this.rows=rows;
  
  })

  this.http.post("http://localhost:5000/countries",{title :"England", code:"ENG"}).subscribe(rows=>{
    this.http.get("http://localhost:5000/countries").subscribe(rows=>{
      this.rows=rows;})
  
  })
  }
   rows2 :any;
  gets(str) {

   
   var str2 =str.toLowerCase();
    for(var i=0;i<this.rows.length ; i++)
    {

      if( this.rows[i].title.toLowerCase().indexOf(str2,0)!==-1 )
      {
       
        console.log(this.rows[i].title);  
      }  
    }


  }*/

 //ngOnInit(): void {}
 
  countriesList: any;
  statelist : any;
  originalcountriesList: any;
  output : any;
  rows : any;
 
  constructor(private http : HttpClient) {
    this.countriesList = [];
    let fetchRequest = fetch("http://localhost:5000/countries");
    let convertedjson = fetchRequest.then(response => response.json());
    convertedjson.then((res) => {
      this.countriesList = this.originalcountriesList = res;
      console.log(res);
    });
  }
  FilterCountries(event: any) {
    let value = event.target.value;
    this.countriesList = this.originalcountriesList.filter((x: any) => {
        if (x.title.toLowerCase().indexOf(value.toLowerCase()) != -1) {
          return true;
        }
        else {
          return false;
        }
      });

  }

  states( ctr : any){
     this.output= [];
    this.statelist = [];
    let fetchRequest = fetch("http://localhost:5000/state");
    let convertedjson = fetchRequest.then(response => response.json());
    convertedjson.then((res) => {
      this.statelist=res;
    //  if(this.statelist.country.toLowerCase().indexOf(ctr.title.toLowerCase()))
     //{ console.log(this.state.title);}
     for( var i =0; i<this.statelist.length;i++)
     {
      if(this.statelist[i].country.toLowerCase()==ctr.toLowerCase())
      {        
        console.log(this.statelist[i].title.toUpperCase());
        this.output.push(this.statelist[i]);
        console.log(JSON.stringify(this.output))
       // console.log(this.output[i].title);
      }
     }
    
     ;
    });
console.log(ctr);   
  }  

  add( input : any , ctry: any ,) {
    let state=input.target.value;
    this.http.post("http://localhost:5000/state",{title :state,country:ctry.title}).subscribe((data)=>{
     console.log('post success');
  });
    alert(ctry.title);
  }
 

  
}
