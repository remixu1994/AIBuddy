namespace Remi.AIBuddy.Model;

public enum ErrorCode
{
    // 内容审查拒绝，您的输入或生成内容可能包含不安全或敏感内容，请您避免输入易产生敏感内容的提示语，谢谢
    ContentFilter = 400,

    // 请求无效，通常是您请求格式错误或者缺少必要参数，请检查后重试
    InvalidRequest = 400,

    /// <summary>
    /// 请求的 tokens 长度过长，请求不要超过模型 tokens 的最长限制
    /// </summary>
    InputTokenLengthTooLong = 400,

    /// <summary>
    /// 请求的 tokens 数和设置的 max_tokens 加和超过了模型规格长度，请检查请求体的规格或选择合适长度的模型
    /// </summary>
    ExceededModelTokenLimit = 400,

    // 请求中的目的（purpose）不正确，当前只接受 'file-extract'，请修改后重新请求
    InvalidPurpose = 400,

    // 上传的文件大小超过了限制，请重新上传
    FileSizeTooLarge = 400,

    // 上传的文件大小为 0，请重新上传
    FileSizeIsZero = 400,

    // 上传的文件总数超限，请删除不用的早期的文件后重新上传
    ExceededMaxFileCount = 400,

    // 鉴权失败，请检查 apikey 是否正确，请修改后重试
    InvalidAuthentication = 401,

    // 鉴权失败，请检查 apikey 是否提供以及 apikey 是否正确，请修改后重试
    IncorrectAPIKey = 401,

    // 账户异常，请检查您的账户余额
    AccountNotActive = 403,

    // 访问的 API 暂未开放
    APINotOpen = 403,

    // 访问其他用户信息的行为不被允许，请检查
    NotAllowedToGetOtherUserInfo = 403,

    // 不存在此模型或者没有授权访问此模型，请检查后重试
    ModelNotFoundOrPermissionDenied = 404,

    // 找不到该用户，请检查后重试
    UserNotFound = 404,

    // 当前并发请求过多，节点限流中，请稍后重试；建议充值升级 tier，享受更丝滑的体验
    EngineOverloaded = 429,

    // 账户额度不足，请检查账户余额，保证账户余额可匹配您 tokens 的消耗费用后重试
    ExceededCurrentTokenQuota = 429,

    // 请求触发了账户并发个数的限制，请等待指定时间后重试
    MaxConcurrencyReached = 429,

    // 请求触发了账户 RPM 速率限制，请等待指定时间后重试
    MaxRPMReached = 429,

    // 请求触发了账户 TPM 速率限制，请等待指定时间后重试
    TPMRateLimitReached = 429,

    /// <summary>
    /// 请求触发了账户 TPD 速率限制，请等待指定时间后重试
    /// </summary>
    TPDRateLimitReached = 429,

    // 解析文件失败，请重试
    FailedToExtractFile = 500,

    /// <summary>
    /// 服务器内部错误，请稍后重试   
    /// </summary>
    UnexpectedOutput = 500
}