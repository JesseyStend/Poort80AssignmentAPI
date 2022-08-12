import { Button, CardHeader, IconButton, LinearProgress, Typography } from "@mui/material";
import * as React from "react";
import { useState, useEffect } from "react";
import MuiTable from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import { useParams } from "react-router-dom";
import { Add, Delete, Edit } from "@mui/icons-material";
import { Stack } from "@mui/system";

interface TableProps {}
interface ITableData {
  tableRowProps: string[];
  rows: any[];
}

const Table: React.FunctionComponent<TableProps> = () => {
  const [tableData, setTableData] = useState<ITableData>();
  let { section } = useParams();

  useEffect(() => {
    fetch(`https://localhost:7143/api/${section}`)
      .then((r) => r.json())
      .then((r: any[]) => {
        let [first] = r;
        setTableData({
          tableRowProps: Object.keys(first),
          rows: r,
        });
      });
  }, []);

  return !tableData ? (
    <LinearProgress />
  ) : (
    <>
      <CardHeader
        title={section}
        action={
          <Button variant='contained' startIcon={<Add />} href={`/${section?.slice(0, -1)}/add`}>
            Add entry
          </Button>
        }
      />
      <TableContainer>
        <MuiTable aria-label='simple table'>
          <TableHead>
            <TableRow>
              {tableData.tableRowProps.map((prop) => (
                <TableCell>{prop}</TableCell>
              ))}
              <TableCell align='right'>Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tableData.rows.map((row) => (
              <TableRow key={row.name} sx={{ "&:last-child td, &:last-child th": { border: 0 } }}>
                {tableData.tableRowProps.map((prop) => (
                  <TableCell component='th' scope='row'>
                    {typeof row[prop] === "object" ? row[prop].map((p: { name: string }) => p.name).join(", ") : row[prop]}
                  </TableCell>
                ))}
                <TableCell align='right'>
                  <Stack direction='row' spacing={2} justifyContent='flex-end'>
                    <IconButton href={`/${section?.slice(0, -1)}/edit/${row.id}`}>
                      <Edit />
                    </IconButton>
                    <IconButton>
                      <Delete />
                    </IconButton>
                  </Stack>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </MuiTable>
      </TableContainer>
    </>
  );
};

export default Table;
