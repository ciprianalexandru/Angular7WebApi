import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';  
import { Observable } from 'rxjs';
import { DepartmentService } from '../department.service'
import { Department} from '../department';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  dataSaved = false;
  allDepartments: Observable<Department[]>;
  departmentForm: any;
  departmentIdUpdate = null;
  message = null;

  constructor(private formbuilder: FormBuilder,private departmentService:DepartmentService) { }

  ngOnInit() {
    this.departmentForm = this.formbuilder.group({  
    Name: ['', ],  
    Description: ['', ],  
    //   // EmailId: ['', [Validators.required]],  
    //   // Gender: ['', [Validators.required]],  
    //   // Address: ['', [Validators.required]],  
    //   // PinCode: ['', [Validators.required]],  
    });
    this.getDepartments();
  }

  getDepartments() {
    //debugger;
    this.allDepartments = this.departmentService.getAllDepartments();    
  }

  loadDepartmentToEdit(Id: string) {  
    this.departmentService.getDepartmentById(Id).subscribe(department=> {  
      this.message = null;  
      this.dataSaved = false;  
      this.departmentIdUpdate = department.Id;  
      this.departmentForm.controls['Name'].setValue(department.Name);  
      this.departmentForm.controls['Description'].setValue(department.Description);
    });  
  
  }

  CreateDepartment(department: Department) {  
    if (this.departmentIdUpdate == null) {  
      this.departmentService.createDepartment(department).subscribe(  
        () => {  
          this.dataSaved = true;  
          this.message = 'Record saved Successfully'; 
          //debugger; 
          this.getDepartments();  
          this.departmentIdUpdate = null;  
          this.departmentForm.reset();  
        }  
      );  
    } else {  
      department.Id = this.departmentIdUpdate;  
      this.departmentService.updateDepartment(department).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Updated Successfully';  
        this.getDepartments();  
        this.departmentIdUpdate = null;  
        this.departmentForm.reset();
      });  
    }  
  }

  deleteDepartment(Id: string) { 
    //debugger; 
    if (confirm("Are you sure you want to delete this ?")) {   
      this.departmentService.deleteDepartmentById(Id).subscribe(() => {  
        this.dataSaved = true;  
        this.message = 'Record Deleted Succefully';  
        this.getDepartments();  
        this.departmentIdUpdate = null;  
        this.departmentForm.reset();      
      });  
    } 
  }

  onFormSubmit() {  
    this.dataSaved = false;  
    const department = this.departmentForm.value; 
    //debugger; 
    this.CreateDepartment(department);  
    this.departmentForm.reset();  
  }

}
