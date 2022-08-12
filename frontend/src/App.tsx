import { AppBar, CardContent, Divider, Grid, Link, Paper, Slide, Toolbar, Typography, useScrollTrigger } from "@mui/material";
import React from "react";
import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import BreadCrumbsComp from "./Components/Beadcrumbs";
import Department from "./Pages/Department";
import Employee from "./Pages/Employee";
import Home from "./Pages/Home";
import Table from "./Pages/Table";

interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children: React.ReactElement;
}

function App() {
  return (
    <div>
      <BrowserRouter>
        <AppBar>
          <Toolbar></Toolbar>
        </AppBar>
        <Grid container direction='column' sx={{ height: "100vh", width: "100vw" }}>
          <Grid item xs='auto' component={Paper} square>
            <Toolbar />
          </Grid>
          <Grid item xs='auto' component={CardContent}>
            <BreadCrumbsComp />
          </Grid>
          <Grid item xs='auto'>
            <Divider />
          </Grid>
          <Grid item xs component={Paper}>
            <Routes>
              <Route path='/home' element={<Home />} />
              <Route path='/table/:section' element={<Table />} />
              <Route path='/employee/:action/:id' element={<Employee/>}/>
              <Route path='/employee/:action' element={<Employee/>}/>
              <Route path='/department/:action/:id' element={<Department/>}/>
              <Route path='/department/:action' element={<Department/>}/>
              <Route path='*' element={<Navigate replace to='/home' />} />
            </Routes>
          </Grid>
        </Grid>
      </BrowserRouter>
    </div>
  );
}

export default App;
