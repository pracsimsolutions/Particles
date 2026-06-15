#pragma once
#include <cstdio>
#include <cmath>
#include <vector>
#include <functional>

struct TestCase { const char* name; std::function<void()> fn; };
inline std::vector<TestCase>& tests() { static std::vector<TestCase> t; return t; }
inline int& failures() { static int f = 0; return f; }

struct Reg { Reg(const char* n, std::function<void()> f) { tests().push_back({n, f}); } };
#define TEST(name) \
    static void name(); static Reg reg_##name(#name, name); static void name()

#define CHECK(cond) do { if (!(cond)) { \
    std::printf("  FAIL %s:%d  CHECK(%s)\n", __FILE__, __LINE__, #cond); failures()++; } } while(0)
#define CHECK_NEAR(a, b, eps) do { double _a=(a), _b=(b); if (std::fabs(_a-_b) > (eps)) { \
    std::printf("  FAIL %s:%d  CHECK_NEAR(%s=%g, %s=%g, %g)\n", __FILE__, __LINE__, #a,_a,#b,_b,(double)(eps)); \
    failures()++; } } while(0)

inline int runAllTests() {
    for (auto& t : tests()) { std::printf("[ RUN ] %s\n", t.name); t.fn(); }
    std::printf(failures() ? "\n%d FAILURE(S)\n" : "\nALL PASSED\n", failures());
    return failures() ? 1 : 0;
}
