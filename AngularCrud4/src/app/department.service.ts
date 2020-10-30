import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Department } from './department'; 

@Injectable({
  providedIn: 'root'
})

export class DepartmentService {

  //url = 'http://localhost:65389/api';
  url = 'http://localhost:54544/api/Departments';

  constructor(private http: HttpClient) { }

  getAllDepartments(): Observable<Department[]> { 
    //debugger; 
    return this.http.get<Department[]>(this.url + '/GetDepartments');  
  }
  
  getDepartmentById(departmentId: string): Observable<Department> {  
    return this.http.get<Department>(this.url + '/GetDepartmentById/' + departmentId);  
  }

  createDepartment(department: Department): Observable<Department> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    
    var result = this.http.post<Department>(this.url + '/InsertDepartment/', department, httpOptions);  
//debugger;
    return result;
  }
  
  updateDepartment(employee: Department): Observable<Department> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };

    return this.http.put<Department>(this.url + '/UpdateDepartment/',

    employee, httpOptions);  
  }

  deleteDepartmentById(departmentId: string): Observable<number> {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };

    return this.http.post<number>(this.url + '/DeleteDepartment/' + departmentId, httpOptions); 
  }

}
