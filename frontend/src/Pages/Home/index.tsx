import { Card as MuiCard, CardContent, CardActionArea, CardHeader, Grid, styled, Typography } from "@mui/material";
import * as React from "react";
import { useState, useEffect } from "react";

interface HomeProps {}

const Card = styled(MuiCard)({
    width: "300px"
})

const Home: React.FunctionComponent<HomeProps> = () => {
  return (
    <Grid sx={{ height: "100%" }} spacing={2} container direction='column' alignContent='center' justifyContent='center' component={CardContent}>
      <Grid item>
        <Typography variant='h1' fontWeight='bold' color='primary'>
          Home
        </Typography>
        <Typography variant='caption'>The place where you chose your path</Typography>
      </Grid>
      <Grid item>
        <Grid container spacing={2}>
          <Grid item>
            <Card variant="outlined">
              <CardActionArea href="table/employees">
                <CardHeader title='Employees table' subheader='A table full of colleagues and co-workers' />
              </CardActionArea>
            </Card>
          </Grid>
          <Grid item>
            <Card variant="outlined">
              <CardActionArea href="table/departments">
                <CardHeader title='Departments table' subheader='A table full of areas of special expertise or responsibility. ' />
              </CardActionArea>
            </Card>
          </Grid>
        </Grid>
      </Grid>
    </Grid>
  );
};

export default Home;
