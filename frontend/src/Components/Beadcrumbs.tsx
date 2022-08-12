import { Breadcrumbs, Link, Typography } from "@mui/material";
import * as React from "react";
import { useState, useEffect } from "react";
import { useLocation } from "react-router-dom";

interface BreadCrumbsProps {}

const BreadCrumbsComp: React.FunctionComponent<BreadCrumbsProps> = () => {
  let location = useLocation();

  const genCrumbs = () => {
    let path = "/";
    let crumbs = location.pathname.split("/").slice(1)

    return crumbs.map((crumb, index) => {
      let isLast = crumbs.length <= index + 1;

      path += isLast ? `${crumb}` : `${crumb}/`;

      return isLast ? (
        <Typography color='text.primary'>{crumb}</Typography>
      ) : (
        <Link underline='hover' color='primary' href={path}>
          {crumb}
        </Link>
      );
    });
  };

  return <Breadcrumbs>{genCrumbs()}</Breadcrumbs>;
};

export default BreadCrumbsComp;
