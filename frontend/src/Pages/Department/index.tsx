import { Save } from "@mui/icons-material";
import { Button, Paper, CardActions, CardContent, CardHeader, Grid, List, ListItemButton, ListItemText, TextField, LinearProgress, ListItem } from "@mui/material";
import * as React from "react";
import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import IDepartment from "../../Interfaces/IDepartment";

interface DepartmentProps {}

const Department: React.FunctionComponent<DepartmentProps> = () => {
  const [department, setDepartment] = useState<IDepartment>();
  const { action, id } = useParams();
  const navigate = useNavigate();

    const handleSubmit: React.FormEventHandler<HTMLFormElement> = (e)=>{
        e.preventDefault();
        const formData = new FormData(e.currentTarget);
        fetch("https://localhost:7143/api/departments" + (action === "edit"? `/${id}` : ""), {
            method: action === "edit"? "PUT" : "Post",
            headers: {
                "Content-Type": "application/json" 
            },
            body: JSON.stringify({
                name: formData.get("name"),
                description: formData.get("description")
            })
        })
          .then(()=>navigate("/table/departments"))
    }

  useEffect(() => {
    fetch("https://localhost:7143/api/departments/" + id)
      .then((r) => r.json())
      .then(setDepartment);
  }, [action, id]);

  return action === "add" || department ? (
    <Grid container component={"form"} spacing={2} onSubmit={handleSubmit}>
      <Grid item xs>
        <CardHeader title={`Department `} />
        <CardContent>
          <TextField required label='name' name='name' fullWidth defaultValue={department?.name || ""}/>
          <TextField sx={{mt: "8px"}} required label='description' multiline minRows={3} name='description' fullWidth defaultValue={department?.description || ""}/>
        </CardContent>
      </Grid>
      <Grid item xs={5}>
        <CardHeader title={`Connected Employees`} />
        <List component={Paper} variant='outlined' disablePadding>
          {department?.employees? department.employees.map((employee) => (
            <ListItemButton href={`/employee/${employee.id}`}>
              <ListItemText primary={employee.name} />
            </ListItemButton>
          )) : (
            <ListItem>
              <ListItemText primary="No connected employees yet connected" />
            </ListItem>
          )}
        </List>
      </Grid>
      <Grid item xs={12}>
        <CardActions>
          <Button sx={{ ml: "8px" }} type="submit" variant='contained' startIcon={<Save />}>
            Save
          </Button>
          <Button sx={{ ml: "8px" }} variant='outlined' href='/table/departments'>
            Cancel
          </Button>
        </CardActions>
      </Grid>
    </Grid>
  ) : (
    <LinearProgress />
  );
};

export default Department;
