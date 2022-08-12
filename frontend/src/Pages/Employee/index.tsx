import { Save } from "@mui/icons-material";
import { Button, Paper, CardActions, CardContent, CardHeader, Grid, List, ListItemButton, ListItemText, TextField, LinearProgress } from "@mui/material";
import * as React from "react";
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import IDepartment from "../../Interfaces/IDepartment";
import IEmployee from "../../Interfaces/IEmployee";

interface EmployeeProps {}

const Employee: React.FunctionComponent<EmployeeProps> = () => {
  const [employee, setEmployee] = useState<IEmployee>();
  const [departments, setDepartments] = useState<IDepartment[]>([]);
  const [selectedDepartment, setSelectedDepartment] = useState<number>();
  const { action, id } = useParams();
  const navigate = useNavigate();

    const handleSubmit: React.FormEventHandler<HTMLFormElement> = (e)=>{
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        fetch("https://localhost:7143/api/Employees" + (action === "edit"? `/${id}` : ""), {
            method: action === "edit"? "PUT" : "Post",
            headers: {
                "Content-Type": "application/json" 
            },
            body: JSON.stringify({
                name: formData.get("fullname"),
                departmentId: selectedDepartment || employee?.departmentId
            })
        })
          .then(()=>navigate("/table/employees"))
        
    }

  useEffect(() => {
    fetch("https://localhost:7143/api/Departments")
      .then((r) => r.json())
      .then(setDepartments);
  }, []);

  useEffect(() => {
    fetch("https://localhost:7143/api/Employees/" + id)
      .then((r) => r.json())
      .then(setEmployee);
  }, [action, id]);

  return action === "add" || employee ? (
    <Grid container component={"form"} spacing={2} onSubmit={handleSubmit}>
      <Grid item xs>
        <CardHeader title={`Employee `} />
        <CardContent>
          <TextField required label='name' name='fullname' fullWidth defaultValue={employee?.name || ""}/>
        </CardContent>
      </Grid>
      <Grid item xs={5}>
        <CardHeader title={`Selected department`} />
        <List component={Paper} variant='outlined' disablePadding>
          {departments.map((department) => (
            <ListItemButton onClick={()=>setSelectedDepartment(department.id)} selected={department.id === (selectedDepartment || employee?.departmentId)}>
              <ListItemText primary={department.name} secondary={department.description} />
            </ListItemButton>
          ))}
        </List>
      </Grid>
      <Grid item xs={12}>
        <CardActions>
          <Button sx={{ ml: "8px" }} type="submit" variant='contained' startIcon={<Save />}>
            Save
          </Button>
          <Button sx={{ ml: "8px" }} variant='outlined' href='/table/employees'>
            Cancel
          </Button>
        </CardActions>
      </Grid>
    </Grid>
  ) : (
    <LinearProgress />
  );
};

export default Employee;
