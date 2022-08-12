import IEmployee from "./IEmployee";

export default interface IDepartment {
    name:	string;
    description: string;
    id: number;
    employees: IEmployee[]
}