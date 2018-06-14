
// DemoInteropDlg.cpp : implementation file
//

#include "stdafx.h"
#include "DemoInterop.h"
#include "DemoInteropDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAboutDlg dialog used for App About
namespace ManagedCode
{
	using namespace System;
	using namespace System::Windows;
	using namespace System::Windows::Interop;
	using namespace System::Windows::Media;
	using namespace WPFClock;

	HWND GetHwnd(HWND parent, int x, int y, int width, int height) {
		HwndSource^ source = gcnew HwndSource(
			0, // class style
			WS_VISIBLE | WS_CHILD, // style
			0, // exstyle
			x, y, width, height,
			"hi", // NAME
			IntPtr(parent)        // parent window 
		);

		//UIElement^ page = gcnew WPFClock::Clock();
		//WPFClock::MyWPFUserControl^ control = gcnew WPFClock::MyWPFUserControl();
		UIElement^ control = gcnew WPFClock::MyWPFUserControl();
		source->RootVisual = control;
		return (HWND)source->Handle.ToPointer();
	}
}


class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Dialog Data
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()


// CDemoInteropDlg dialog



CDemoInteropDlg::CDemoInteropDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDemoInteropDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDemoInteropDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STC_WPF_HOST, m_stcHost);
}

BEGIN_MESSAGE_MAP(CDemoInteropDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, &CDemoInteropDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// CDemoInteropDlg message handlers

BOOL CDemoInteropDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CDemoInteropDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialogEx::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDemoInteropDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDemoInteropDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CDemoInteropDlg::OnBnClickedButton1()
{
	// TODO: Add your control notification handler code here
	// Get the handle of the the static control in the dialog.
	HWND hwndHost = m_stcHost.GetSafeHwnd();

	System::Windows::Interop::HwndSourceParameters^ sourceParams = gcnew System::Windows::Interop::HwndSourceParameters("EnetCapacityWpfSourceWnd");
	// This sets the position within the parent window
	sourceParams->PositionX = 0;
	sourceParams->PositionY = 0;
	sourceParams->Width = 100;
	sourceParams->Height = 100;
	sourceParams->ParentWindow = System::IntPtr(hwndHost);
	sourceParams->WindowStyle = WS_VISIBLE | WS_CHILD;

	CEnetCapacityWpfMgr::m_Control= gcnew WPFClock::Clock();
	CEnetCapacityWpfMgr::m_hwndSource = gcnew System::Windows::Interop::HwndSource(*sourceParams);
	CEnetCapacityWpfMgr::m_hwndSource->RootVisual = CEnetCapacityWpfMgr::m_Control;
}
