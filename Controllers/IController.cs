﻿using Microsoft.AspNetCore.Mvc;

namespace API_for_mobile_app.Controllers
{
    public interface IController
    {
        ActionResult GetList();
    }
}
