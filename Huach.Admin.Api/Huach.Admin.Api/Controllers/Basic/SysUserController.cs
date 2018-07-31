using Huach.Admin.Models.Basic;
using Huach.Admin.Service.Basic;
using Huach.Admin.ViewModels.Base;
using Huach.Framework.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Description;
namespace Huach.Admin.Api.Controllers.Basic
{
    /// <summary>
    /// SysUserController 
    /// </summary>
    public class SysUserController : BaseApiController
    {
        private readonly SysUserService _sysUserService;
        public SysUserController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysUserDeleteRequest request)
        {
            var result = _sysUserService.Delete(a => a.Id == request.Id);
            if (result > 0)
            {
                return Succeed(result, "ɾ���ɹ�");
            }
            else
            {
                return Fail("ɾ��ʧ��");
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysUserAddRequest request)
        {
            var entity = new SysUser
            {

            };
            var result = _sysUserService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysUserAddResponse
                {
                    Id = entity.Id
                }, "�����ɹ�");
            }
            else
            {
                return Fail("����ʧ��");
            }
        }
        /// <summary>
        /// �޸ģ�ע�⣺û���޸ĵ�ҲҪ��ԭ�������ݴ��أ�
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysUserUpdateRequest request)
        {
            var entity = new SysUser
            {
                Id = request.Id,
            };
            var result = _sysUserService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysUserUpdateResponse
                {
                    Id = entity.Id
                }, "�����ɹ�");
            }
            else
            {
                return Fail("����ʧ��");
            }
        }
        /// <summary>
        /// ����id��ѯ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysUserFindRequest request)
        {
            var result = _sysUserService.Find(request.Id);
            if (result == null)
            {
                return Fail("��Ǹ��û�鵽����");
            }
            return Succeed(new SysUserFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysUserSearchRequest request)
        {
            Expression<Func<SysUser, bool>> expression = a => true;
            var result = _sysUserService.LoadPaging(expression, a => new SysUserSearchItem
            {

            }, request);
            return Succeed(new SysUserSearchResponse
            {
                Count = result.Count,
                Items = result.Items,
                Total = result.Total,
            });
        }


    }



    /// <summary>
    /// ɾ���������
    /// </summary>
    public class SysUserDeleteRequest : BaseRequest
    {
        /// <summary>
        /// id ����
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// ɾ����Ӧ
    /// </summary>
    public class SysUserDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// ����������
    /// </summary>
    public class SysUserAddRequest : BaseRequest
    {

    }
    /// <summary>
    /// �����Ӧ
    /// </summary>
    public class SysUserAddResponse : BaseResponse
    {
        public int Id { get; set; }
    }
    public class SysUserUpdateRequest : BaseRequest
    {
        /// <summary>
        /// id ����
        /// </summary>
        [Required]
        public int Id { get; set; }
    }

    public class SysUserUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// ɾ���������
    /// </summary>
    public class SysUserFindRequest : BaseRequest
    {
        /// <summary>
        /// id ����
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// ɾ����Ӧ
    /// </summary>
    public class SysUserFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// �����������
    /// </summary>
    public class SysUserSearchRequest : BasePagingRequest
    {
    }
    /// <summary>
    /// ��ѯ���������
    /// </summary>
    public class SysUserSearchResponse : BasePagingResponse<SysUserSearchItem>
    {
    }
    /// <summary>
    /// ��ѯ��Ӧ
    /// </summary>
    public class SysUserSearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}

