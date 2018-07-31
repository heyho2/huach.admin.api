﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Admin.ViewModels.Base
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class BaseRequest
    {
    }
    /// <summary>
    /// 分页请求
    /// </summary>
    public abstract class BasePagingRequest : BaseRequest
    {
        /// <summary>
        /// 页数
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 20;
        /// <summary>
        /// 排序方向
        /// </summary>
        public string Direction { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField { get; set; }
    }
}
