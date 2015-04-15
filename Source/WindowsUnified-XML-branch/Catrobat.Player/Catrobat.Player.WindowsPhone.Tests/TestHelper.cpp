#include "pch.h"
#include "TestHelper.h"

std::string TestHelper::ConvertPlatformStringToString(Platform::String^ input)
{
    std::wstring foo(input->Begin());
    std::string res(foo.begin(), foo.end());
    return res;
}

Platform::String^ TestHelper::ConvertStringToPlatformString(std::string input)
{
    std::string s_str = std::string(input);
    std::wstring wid_str = std::wstring(s_str.begin(), s_str.end());
    const wchar_t* w_char = wid_str.c_str();
    return ref new Platform::String(w_char);
}