import {Component, Query, ViewChild} from '@angular/core';
import {
  Edit,
  EditSettings,
  EditSettingsModel,
  GridComponent,
  PageSettingsModel, ToolbarItem, ToolbarItems,
  ToolbarService
} from "@syncfusion/ej2-angular-grids";
import { Ajax } from '@syncfusion/ej2-base';
import { DataManager, UrlAdaptor, ReturnOption } from '@syncfusion/ej2-data'

@Component({
  selector: 'app-root',
  template: ` <br><br><br>
    <ejs-grid #Grid
              [allowPaging]="true"
              [pageSettings]="pageSettings"
              [allowSorting]="true"
              [allowFiltering]="true"
              [allowTextWrap]="true"
              [editSettings] = "editOptions"
              [toolbar]="toolBarOptions"
    >
      <e-columns>
        <e-column field="departmentName" headerText="Наименование учреждения" textAlign="center"></e-column>
        <e-column field="surname" headerText="Фамилия" textAlign="center"></e-column>
        <e-column field="firstName" headerText="Имя" textAlign="center"></e-column>
        <e-column field="patronymicName" headerText="Отчество" textAlign="center"></e-column>
        <e-column field="birthDate" headerText="Дата рождения" textAlign="center"></e-column>
        <e-column field="dateOfEmployee" headerText="Дата устройства на работу" textAlign="center"></e-column>
        <e-column field="salary" headerText="Зарплата" textAlign="center" ></e-column>
      </e-columns>
    </ejs-grid>`,
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  // @ts-ignore
  @ViewChild('Grid') public mainGrid: GridComponent;

  public pageSettings: PageSettingsModel = { pageSize: 2 };
  // @ts-ignore
  public editOptions: EditSettingsModel;
  // @ts-ignore
  public toolBarOptions: ToolbarItems[];

  ngOnInit(): void {
    this.editOptions = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Batch'};
    this.toolBarOptions = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
  }

  ngAfterViewInit() {
    const grid = this.mainGrid;
    const ajax = new Ajax("https://localhost:7251/api/v1/employee/list", 'GET');
    ajax.send();
    ajax.onSuccess = (data: string) => {
      grid.dataSource = JSON.parse(data);
    }
  }
}
